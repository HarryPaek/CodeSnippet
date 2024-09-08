
    function getExcelfile(ac) {
        return new Promise((resolve, reject) => {
            const file = ac.m_formData.m_source.popupView.domNode[0].files[0];
            const reader = new FileReader();
            reader.onload = function (e) {
                const arrayBuffer = e.target.result;
                try {
                    const workbook = XLSX.read(arrayBuffer, { type: 'array' });
                    const firstSheetName = workbook.SheetNames[0];
                    const worksheet = workbook.Sheets[firstSheetName];
                    const range = XLSX.utils.decode_range(worksheet['!ref']);
                    const data = [];
                    for (let rowNum = range.s.r; rowNum <= range.e.r; rowNum++) {
                        const row = [];
                        for (let colNum = range.s.c; colNum <= range.e.c; colNum++) {
                            const address = XLSX.utils.encode_cell({ r: rowNum, c: colNum });
                            const cell = worksheet[address];
                            let value = (cell ? cell.v : undefined);
                            if (typeof value === 'undefined') {
                                value = '';
                            }
                            row.push(value);
                        }
                        data.push(row);
                    }
                    resolve(data);
                } catch (error) {
                    reject(error);
                    var elements = document.getElementsByClassName('csi-wait');
                    while (elements.length > 0) {
                        elements[0].parentNode.removeChild(elements[0]);
                    }
                }
            };
            reader.onerror = function (e) {
                reject(e.target.error);
                var elements = document.getElementsByClassName('csi-wait');
                while (elements.length > 0) {
                    elements[0].parentNode.removeChild(elements[0]);
                }
            };
            reader.readAsArrayBuffer(file);
        });
    }

    function CreateOverlayScreen(ac, callback) {

        var csiWait = document.createElement('div');
        csiWait.className = "csi-wait";
    
        var csiLoadingCircles = document.createElement('div');
        csiLoadingCircles.className = "csi-loading-circles";
    
        var csiLoadingCircle1 = document.createElement('div');
        csiLoadingCircle1.className = "csi-loading-circle1";
    
        var csiLoadingCircle2 = document.createElement('div');
        csiLoadingCircle2.className = "csi-loading-circle2";
    
        var csiLoadingCircle3 = document.createElement('div');
        csiLoadingCircle3.className = "csi-loading-circle3";
    
        var csiLoadingCircle4 = document.createElement('div');
        csiLoadingCircle4.className = "csi-loading-circle4";
    
        csiLoadingCircles.appendChild(csiLoadingCircle1);
        csiLoadingCircles.appendChild(csiLoadingCircle2);
        csiLoadingCircles.appendChild(csiLoadingCircle3);
        csiLoadingCircles.appendChild(csiLoadingCircle4);
    
        csiWait.appendChild(csiLoadingCircles);
   
        document.body.appendChild(csiWait);

        //setTimeout(function(){
        //    callback();
        //}, 10);
		callback();
    }

    function createMaterialFromExcelData(ac, getExcelData, ac_writer) {
        if(getExcelData&&getExcelData.length>1){
            for(var i=1; i<getExcelData.length; i++){
                var newMaterialData = comm.createUrl();
                var MaterialAttrCreated = false;
                ac_writer.createNode(newMaterialData, "Material");
                for(var j=0; j<getExcelData[i].length; j++){
                    if(ac.widget._defaultCustomView.defView.m_headings[j].hasOwnProperty('m_id')&&ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_id=="Images"&&getExcelData[i][j]!=""&&getExcelData[i][j]!=null){
                        //find image in library by it's name
                        var imageArray = {};
                        var imageSearch = new Search();
                        var imageQuery = imageSearch.getQuery();
                        imageQuery.Node("Type", "EQ", "Image").Attr("Node Name", "RE", getExcelData[i][j]+".%").RefAttr("UploadedByUser", "EQ", sessionStore.user.$URL);
                        var resultImage = imageSearch.execute({sync:true});
                        var imageRef = resultImage.getResultNodes();
                        if(imageRef&&imageRef.length>0){
                            var thisImage="";
                            for (var k = 0; k < imageRef.length; k++) {
                                if (!thisImage || imageRef[k].$CT > thisImage.$CT) {
                                    thisImage = imageRef[k];
                                }
                            }
                            if (thisImage) {
                                var thisURL = thisImage.$URL;
                                imageArray[""] = thisURL;
                                imageArray[1] = thisURL;
                            }
                        }
                        ac_writer.changeNode(newMaterialData).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                        ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, imageArray);
                    }else if(ac.widget._defaultCustomView.defView.m_headings[j].hasOwnProperty('m_id')&&getExcelData[i][j]!=""&&getExcelData[i][j]!=null&&ac.widget._defaultCustomView.defView.m_headings[j].m_path=="Child:Attributes"){
                        if(!MaterialAttrCreated){
                            var NewMaterialAttributes = comm.createUrl();
                            ac_writer.createNode(NewMaterialAttributes, "MaterialAttributes").changeAttribute("__Parent__", "ref", newMaterialData);
                            ac_writer.changeNode(newMaterialData).changeAttribute("Attributes", "ref", NewMaterialAttributes);
                            MaterialAttrCreated = true;
                        }
                        if(ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_id=="Composition"){
                            var CompositionDatas = {};
                            getExcelData[i][j].split(',').forEach(part => {
                                const [percentage, material] = part.trim().split('%');
                                CompositionDatas[material.trim()] = parseInt(percentage);
                            });
                            if (Object.keys(CompositionDatas).length > 0) {
                                var compositionVector = [];
                                for (var compo in CompositionDatas) {
                                    if (CompositionDatas.hasOwnProperty(compo)) {
                                        var NewMaterialComposition = comm.createUrl();
                                        var compSearch = new Search();
                                        var compQuery = compSearch.getQuery();
                                        compQuery.Node("Type", "EQ", "Composition").Attr("Node Name", "EQ", compo);
                                        var resultcomp = compSearch.execute({sync:true});
                                        var compRef = resultcomp.getResultNodes();
                                        if(compRef&&compRef.length==1){
                                            ac_writer.createNode(NewMaterialComposition, "MaterialComposition");
                                            ac_writer.changeNode(NewMaterialComposition).changeAttribute("Composition", "ref", compRef[0].$URL).changeAttribute("Percentage", "double", CompositionDatas[compo]);
                                            ac_writer.changeNode(NewMaterialComposition).changeAttribute("__Parent__", "ref", NewMaterialAttributes);
                                            ac_writer.execute({ sync: true });
                                            compositionVector.push(NewMaterialComposition);
                                        }
                                    }
                                }
                                ac_writer.changeNode(NewMaterialAttributes).changeAttribute("TechnicalComposition", "refvector", compositionVector)
                                .changeAttribute("Composition", "string", getExcelData[i][j]).changeAttribute("DetailedComposition", "string", getExcelData[i][j]);
                            }
                        }else{
                            switch(ac.widget._defaultCustomView.defView.m_headings[j]._dp.type) {
                                case "enum": {
                                    var en_LocaleConfiguration = ac.m_cache.addNode("centric://REFLECTION/INSTANCE/CompanyInfo/Global?Path=Child:LocaleConfiguration/Index:en").Resources;
                                    var enumValue = Object.keys(en_LocaleConfiguration).find(key => key.includes(ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_format) && en_LocaleConfiguration[key] === getExcelData[i][j]);
                                    if(enumValue){
                                        ac_writer.changeNode(NewMaterialAttributes).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                            ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, enumValue);
                                    }else{
                                        ac_writer.changeNode(NewMaterialAttributes).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                            ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_format+":"+getExcelData[i][j]);
                                    }
                                    break;
                                };
                                case "enumlist": {
                                    var thisExcelData = getExcelData[i][j].toString();
                                    var ExcelEnumList = [];
                                    var en_LocaleConfiguration = ac.m_cache.addNode("centric://REFLECTION/INSTANCE/CompanyInfo/Global?Path=Child:LocaleConfiguration/Index:en").Resources;
                                    var splitValues = thisExcelData.split(",");
                                    for (var value of splitValues) {
                                        var trimmedValue = value.trim();
                                        var enumlistValue = Object.keys(en_LocaleConfiguration).find(key => key.includes(ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_format) && en_LocaleConfiguration[key] === trimmedValue);
                                        if(enumlistValue){
                                            ExcelEnumList.push(enumlistValue);
                                        }else{
                                            ExcelEnumList.push(ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_format+":"+thisExcelData);
                                        }
                                    }
                                    ac_writer.callMethod("DataStore", "UpdateAggregateStoreAttribute")
                                            .addParameter("ParentURL", "cnl", NewMaterialAttributes)//cnl
                                            .addParameter("ParentAttr", "string", ac.widget._defaultCustomView.defView.m_headings[j].m_id)
                                            .addParameter("SetItems", "enumlist",ExcelEnumList);
                                    break;
                                };
                                case "ref": {
                                        var refType = "";
                                        if(ac.widget._defaultCustomView.defView.m_headings[j].m_id=="fl_MaterialCurrency"){
                                            refType = "Currency";
                                        }else if(ac.widget._defaultCustomView.defView.m_headings[j].m_id=="fl_srm_last_size_range"){
                                            refType = "SizeRange";
                                        }else if(ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations.length!=0){
                                            refType = ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations[0].data[0];
                                        }
                                        var refSearch = new Search();
                                        var refQuery = refSearch.getQuery();
                                        refQuery.Node("Type", "EQ", refType ).Attr("Node Name", "EQ", getExcelData[i][j]);
                                        var resultRef = refSearch.execute({sync:true});
                                        var foundRef = resultRef.getResultNodes();
                                        if(foundRef&&foundRef.length==1){
                                            ac_writer.changeNode(NewMaterialAttributes).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                                ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, foundRef[0].$URL);
                                        }
                                    break;
                                };
                                case "refset": {
                                    const stringArray = [];
                                    const refsetSplit = getExcelData[i][j].split(',').map(item => item.trim());
    
                                    refsetSplit.forEach(item => {
                                        const refSets = item.split(",").map(data => data.trim());
                                        stringArray.push(...refSets);
                                    });
                                    let refsetArray = [];
                                    let setType = "";
                                    if(ac.widget._defaultCustomView.defView.m_headings[j].m_id=="fl_srm_sizes"){
                                        setType = "ProductSize";
                                    }else if(ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations.length!=0){
                                        refType = ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations[0].data[0];
                                    }
    
                                    stringArray.forEach((element) => {
                                        var setSearch = new Search();
                                        var setQuery = setSearch.getQuery();
                                        setQuery.Node("Type", "EQ", setType).Attr("Node Name", "EQ", element);
                                        var resultset = setSearch.execute({sync:true});
                                        var setRef = resultset.getResultNodes();
                                        if(setRef && setRef.length == 1) {
                                            refsetArray.push(setRef[0].$URL);
                                        }
                                    });
                                    ac_writer.changeNode(NewMaterialAttributes).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                        ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, refsetArray);
                                    break;
                                };
                                case "reflist": {
                                    const stringArray = [];
                                    const refLiistSplit = getExcelData[i][j].split(',').map(item => item.trim());
                                    refLiistSplit.forEach(item => {
                                        const refLists = item.split(",").map(data => data.trim());
                                        stringArray.push(...refLists);
                                    });
                                    
                                    let refListArray = [];
                                    let listType = "";
                                    if(ac.widget._defaultCustomView.defView.m_headings[j].m_id=="fl_srm_last_factory"){
                                        listType = "Supplier";
                                    }else if(ac.widget._defaultCustomView.defView.m_headings[j].m_id=="fl_srm_mold_season"){
                                        listType = "Season";
                                    }else if(ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations.length!=0){
                                        listType = ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations[0].data[0];
                                    }
    
                                    stringArray.forEach((element) => {
                                        var listSearch = new Search();
                                        var listQuery = listSearch.getQuery();
                                        listQuery.Node("Type", "EQ", listType).Attr("Node Name", "EQ", element);
                                        var resultList = listSearch.execute({sync:true});
                                        var listRef = resultList.getResultNodes();
                                        if(listRef && listRef.length == 1) {
                                            refListArray.push(listRef[0].$URL);
                                        }
                                    });
                                    ac_writer.changeNode(NewMaterialAttributes).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                        ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, refListArray);
                                    break;
                                };
                                case "time": {
                                    var dateInMilliseconds = (getExcelData[i][j] - 25569) * 86400 * 1000;
                                    var excelDate = new Date(dateInMilliseconds);
                                    var jsTimestamp = excelDate.getTime();
                                    ac_writer.changeNode(NewMaterialAttributes).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                        ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, jsTimestamp);
                                    break;
                                };
                                default: {
                                    ac_writer.changeNode(NewMaterialAttributes).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                        ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, getExcelData[i][j]);
                                };
                            }
                        }
                        ac_writer.execute({ sync: true });
                    }else if(ac.widget._defaultCustomView.defView.m_headings[j].hasOwnProperty('m_id')&&getExcelData[i][j]!=""&&getExcelData[i][j]!=null
                    &&ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_id=="Documents"){

                    }else if(ac.widget._defaultCustomView.defView.m_headings[j].hasOwnProperty('m_id')&&getExcelData[i][j]!=""&&getExcelData[i][j]!=null
                    &&ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_id=="ProductColors"){
                        var ColoredMaterial = [];
                        var ColoredMaterialSplit = getExcelData[i][j].split(',');
                        
                        ColoredMaterialSplit.forEach(item => {
                            const colorMaterials = item.trim().split(',').map(color => color.trim());
                            ColoredMaterial.push(...colorMaterials);
                        });
                        if(ColoredMaterial.length>0){
                            var defaultColor = false;
                            for (var colored in ColoredMaterial) {
                                var colorSearch = new Search();
                                var colorQuery = colorSearch.getQuery();
                                colorQuery.Node("Type", "EQ", "ColorSpecification").Attr("Node Name", "EQ", ColoredMaterial[colored]);
                                var resultcolor = colorSearch.execute({sync:true});
                                var resultcolorNodes = resultcolor.getResultNodes();
                                if(resultcolorNodes&&resultcolorNodes.length==1){
                                    var NewMaterialColors = comm.createUrl();
                                    ac_writer.callMethod("Apparel", "NewColorMaterialWithDefault3DMaterial")
										.addParameter("URL", "ref", NewMaterialColors)
										.addParameter("ParentURL", "ref", newMaterialData)
										.addParameter("ParentAttr", "string", "ProductColors")
										.addParameter("ColorSpecification", "ref", resultcolorNodes[0].$URL)
										.addParameter("Type", "string", "ColorMaterial");
                                    if(!defaultColor){
                                        ac_writer.changeNode(newMaterialData).changeAttribute("DefaultColor", "ref", NewMaterialColors);
                                        defaultColor = true;
                                    }
                                }
                            }
                        }
                    }else if(ac.widget._defaultCustomView.defView.m_headings[j].hasOwnProperty('m_id')&&ac.widget._defaultCustomView.defView.m_headings[j].m_id!=null
                    &&ac.widget._defaultCustomView.defView.m_headings[j].m_id!="ModifiedAt"&&ac.widget._defaultCustomView.defView.m_headings[j].m_id!="ModifiedBy"
                    &&ac.widget._defaultCustomView.defView.m_headings[j].m_id!=""&&getExcelData[i][j]!=""&&getExcelData[i][j]!=null){
                        switch(ac.widget._defaultCustomView.defView.m_headings[j]._dp.type) {
                            case "enum": {
                                var en_LocaleConfiguration = ac.m_cache.addNode("centric://REFLECTION/INSTANCE/CompanyInfo/Global?Path=Child:LocaleConfiguration/Index:en").Resources;
                                var enumValue = Object.keys(en_LocaleConfiguration).find(key => key.includes(ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_format) && en_LocaleConfiguration[key] === getExcelData[i][j]);
                                if(enumValue){
                                    ac_writer.changeNode(newMaterialData).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                        ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, enumValue);
                                }else{
                                    ac_writer.changeNode(newMaterialData).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                        ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_format+":"+getExcelData[i][j]);
                                    }
                                break;
                            };
                            case "enumlist": {
                                var thisExcelData = getExcelData[i][j].toString();
                                var ExcelEnumList = [];
                                var en_LocaleConfiguration = ac.m_cache.addNode("centric://REFLECTION/INSTANCE/CompanyInfo/Global?Path=Child:LocaleConfiguration/Index:en").Resources;
                                var splitValues = thisExcelData.split(",");
                                for (var value of splitValues) {
                                    var trimmedValue = value.trim();
                                    var enumlistValue = Object.keys(en_LocaleConfiguration).find(key => key.includes(ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_format) && en_LocaleConfiguration[key] === trimmedValue);
                                    if(enumlistValue){
                                        ExcelEnumList.push(enumlistValue);
                                    }else{
                                        ExcelEnumList.push(ac.widget._defaultCustomView.defView.m_headings[j]._dp.ra.m_format+":"+thisExcelData);
                                    }
                                }
                                ac_writer.callMethod("DataStore", "UpdateAggregateStoreAttribute")
                                        .addParameter("ParentURL", "cnl", newMaterialData)//cnl
                                        .addParameter("ParentAttr", "string", ac.widget._defaultCustomView.defView.m_headings[j].m_id)
                                        .addParameter("SetItems", "enumlist",ExcelEnumList);
                                break;
                            };
                            case "ref": { //ProductType, MaterialOriginalSeason
                                    var refType = "";
                                    if(ac.widget._defaultCustomView.defView.m_headings[j].m_id=="ProductType"){
                                        refType = "MaterialType";
                                    }else if(ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations.length!=0){
                                        refType = ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations[0].data[0];
                                    }
                                    var refSearch = new Search();
                                    var refQuery = refSearch.getQuery();
                                    refQuery.Node("Type", "EQ", refType ).Attr("Node Name", "EQ", getExcelData[i][j]);
                                    var resultRef = refSearch.execute({sync:true});
                                    var foundRef = resultRef.getResultNodes();
                                    if(foundRef&&foundRef.length==1){
                                        ac_writer.changeNode(newMaterialData).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                            ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, foundRef[0].$URL);
                                    }
                                break;
                            };
                            case "refmap": { //Tag
                                const stringArray = [];
                                const refmapSplit = getExcelData[i][j].split(',').map(item => item.trim());

                                refmapSplit.forEach(item => {
                                    const refmaps = item.split(",").map(data => data.trim());
                                    stringArray.push(...refmaps);
                                });
                                if(ac.widget._defaultCustomView.defView.m_headings[j].m_id=="Tags"){
                                    ac_writer.callMethod("SiteAdmin", "SetTags")
                                            .addParameter("URL", "ref", newMaterialData)
                                            .addParameter("TagAttr", "string", "Tags")
                                            .addParameter("Value", "stringlist",stringArray);
                                }
                                break;
                            };
                            case "refset": { //MaterialSecurityGroups, Libraries
                                const stringArray = [];
                                const refsetSplit = getExcelData[i][j].split(',').map(item => item.trim());

                                refsetSplit.forEach(item => {
                                    const refSets = item.split(",").map(data => data.trim());
                                    stringArray.push(...refSets);
                                });
                                let refsetArray = [];
                                let setType = "";
                                if(ac.widget._defaultCustomView.defView.m_headings[j].m_id=="Libraries"){
                                    setType = "LibMaterial";
                                }else if(ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations.length!=0){
                                    refType = ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations[0].data[0];
                                }

                                stringArray.forEach((element) => {
                                    var setSearch = new Search();
                                    var setQuery = setSearch.getQuery();
                                    setQuery.Node("Type", "EQ", setType).Attr("Node Name", "EQ", element);
                                    var resultset = setSearch.execute({sync:true});
                                    var setRef = resultset.getResultNodes();
                                    if(setRef && setRef.length == 1) {
                                        refsetArray.push(setRef[0].$URL);
                                    }
                                });
                                ac_writer.changeNode(newMaterialData).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                    ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, refsetArray);
                                break;
                            };
                            case "reflist": {
                                const stringArray = [];
                                const refLiistSplit = getExcelData[i][j].split(',').map(item => item.trim());
                                refLiistSplit.forEach(item => {
                                    const refLists = item.split(",").map(data => data.trim());
                                    stringArray.push(...refLists);
                                });

                                let refListArray = [];
                                let listType = "";
                                if(ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations.length!=0){
                                    listType = ac.widget._defaultCustomView.defView.m_headings[j]._rca.destinations[0].data[0];
                                }

                                stringArray.forEach((element) => {
                                    var listSearch = new Search();
                                    var listQuery = listSearch.getQuery();
                                    listQuery.Node("Type", "EQ", listType).Attr("Node Name", "EQ", element);
                                    var resultList = listSearch.execute({sync:true});
                                    var listRef = resultList.getResultNodes();
                                    if(listRef && listRef.length == 1) {
                                        refListArray.push(listRef[0].$URL);
                                    }
                                });
                                ac_writer.changeNode(newMaterialData).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                    ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, refListArray);
                                break;
                            };
                            case "time": {
                                var dateInMilliseconds = (getExcelData[i][j] - 25569) * 86400 * 1000;
                                var excelDate = new Date(dateInMilliseconds);
                                var jsTimestamp = excelDate.getTime();
                                ac_writer.changeNode(newMaterialData).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                    ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, jsTimestamp);
                                break;
                            };
                            default: {
                                ac_writer.changeNode(newMaterialData).changeAttribute(ac.widget._defaultCustomView.defView.m_headings[j].m_id,
                                    ac.widget._defaultCustomView.defView.m_headings[j]._dp.type, getExcelData[i][j]);
                            };

                        }
                    }
                }
                ac_writer.execute({ sync: true });
            }
			alert("Complete!");
            ac_writer.setCannotCache();
            ac.widget.refreshWidget();
        } else {
            console.log('Cannot find excel data');
        }
    }

	async function CallExcelFunctions(ac, ac_writer) {
        try {
            await new Promise(resolve => {
                CreateOverlayScreen(ac, () => resolve());
            });
            var data = await getExcelfile(ac);
            createMaterialFromExcelData(ac, data, ac_writer);
        } catch (error) {
            console.error("Error occurred while processing Excel file:", error);
        } finally {
            var elements = document.getElementsByClassName('csi-wait');
            while (elements.length > 0) {
                elements[0].parentNode.removeChild(elements[0]);
            }
        }
    }

return {

        CreateNodeFromExcelData: function(ac) {
            var excelMimeTypes = [
                "application/vnd.ms-excel",
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
            ];
            if(!excelMimeTypes.includes(ac.m_formData.m_source.popupView.domNode[0].files[0].type)){
                throw new Error(locale.resource("You only can upload excel type files."));
            }
            
            var ac_writer = ac.m_writer;
            CallExcelFunctions(ac, ac_writer);
        },
