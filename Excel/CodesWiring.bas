Attribute VB_Name = "CodesWiring"
Option Explicit

Sub Exceute(workingSheet As Worksheet, iOSheetFileFullPath As String, maxNumberOfRowsPerSheet As Long)
    
    Dim wiringProcessorFactory As ClsWiringProcessorFactory
    Dim clsCommon As ClsWiringCommon
    Dim columnMappingList As Collection                           ' Collection�� Index = 1���� ����, ���� �� ������ ��
    Dim columnMapping As ClsColumnMapping                         ' Ÿ��(���) ��Ʈ �� �÷����� Ű�� ������.
    
    Dim rowIndex As Long
    Dim dataRowCount As Long
    Dim cellValues As Collection
    Dim cellValuesList As Collection
        
    Dim workingSheetFirstRow As Range                             ' �������� ù ���� ���ڸ� ���� ����
    Dim workingSheetCell As Range                                 ' �������� ù �� �� ���� ���� ����
    
    Dim ioSheetWorkBook As Workbook                               ' ���� ��Ʈ(������ ����)�� ���� ����
    Dim ioSheetDataSheet As Worksheet                             ' ���� ��Ʈ(������ ��Ʈ)�� ���� ����
    Dim ioSheetFirstRow As Range                                  ' ������ ���� ù ���� ���ڸ� ���� ����
    Dim ioSheetCell As Range                                      ' ������ ���� ù �� �� ���� ���� ����
    Dim ioSheetColumnData As Range                                ' ������ ���ϳ� �� �÷��� ��ü Row �����͸� ���� ����
    Dim wiringDiagramSheet As Worksheet                           ' DATA_SHEET_WIRING_DIAGRAM
    
    
    Set clsCommon = New ClsWiringCommon
    clsCommon.ClearBasicColumnsHeaderText workingSheet                                                               '�۾� ��Ʈ, �⺻ Cell Header Text �� ����
    
    workingSheet.UsedRange.Offset(1).ClearContents                                                                   '���� ������ ����
    Set workingSheetFirstRow = workingSheet.Rows(1).SpecialCells(xlCellTypeConstants)                                '�������� ù ���� ���ڸ� ������ ����
    
    Set ioSheetWorkBook = Workbooks.Open(iOSheetFileFullPath)                                                        '������ ���� ��ü������ ����
    Set ioSheetDataSheet = ioSheetWorkBook.ActiveSheet                                                               '������ ���Ͽ��� ���� �����Ͱ� �ִ� ��Ʈ
    Set ioSheetFirstRow = ioSheetDataSheet.Rows(1).SpecialCells(xlCellTypeConstants)                                 '������ ���� ù ���� ���ڸ� ������ ����
    Set ioSheetColumnData = ioSheetDataSheet.Range(Cells(clsCommon.ROW_INDEX_WIRING_IOLIST_DATA_START, _
                                                         Constants.IOLIST_COLUMN_INDEX_GET_DATA_COUNT), _
                                                   Cells(ioSheetDataSheet.Rows.Count, _
                                                         Constants.IOLIST_COLUMN_INDEX_GET_DATA_COUNT).End(xlUp))    'IO Sheet �������� ������ �ľ��ϱ� ���� ������ �Ǵ�

   '================================================================================================================================================================
   ' ���� ��Ʈ�� ��� ��Ʈ�� Column Mapping�� columnMappingList�� ����
   '================================================================================================================================================================
    Set columnMappingList = New Collection
    
    For Each workingSheetCell In workingSheetFirstRow.Cells                                                          '�������� ù �� �� ���� ��ȯ
        For Each ioSheetCell In ioSheetFirstRow.Cells                                                                '������ ���� ù �� �� ���� ��ȯ
            If workingSheetCell = ioSheetCell Then                                                                   '�� �����Ͱ� ��ġ�ϸ�
                
                Set columnMapping = New ClsColumnMapping
                columnMapping.ColumnDescription = ioSheetCell
                columnMapping.TargetColumn = workingSheetCell.Column
                columnMapping.SourceColumn = ioSheetCell.Column
                
                columnMappingList.add columnMapping
                Set columnMapping = Nothing
                
                Exit For                                                                                             ' ��ġ�ϴ� ���� ã���� ���� workingSheetCell��
            End If
        Next ioSheetCell
    Next workingSheetCell
    
   '================================================================================================================================================================
   ' ���� ��Ʈ ���� cellValuesList�� ����
   '================================================================================================================================================================
    Set cellValuesList = New Collection
    dataRowCount = ioSheetColumnData.Rows.Count
    
    For rowIndex = 0 To dataRowCount - 1
        Set cellValues = New Collection
        
        For Each columnMapping In columnMappingList
            cellValues.add Item:=ioSheetDataSheet.Cells(clsCommon.ROW_INDEX_WIRING_IOLIST_DATA_START + rowIndex, columnMapping.SourceColumn).value, key:=columnMapping.TargetColumnText
        Next columnMapping
        
        cellValuesList.add cellValues
        Set cellValues = Nothing
    Next rowIndex
        
    ioSheetWorkBook.Close False                                                                                  '���� ������ ������� ����

   '================================================================================================================================================================
   ' ������ ���� ��Ʈ�� �� ���� ó��
   '================================================================================================================================================================
    Set wiringDiagramSheet = Worksheets(Constants.DATA_SHEET_WIRING_DIAGRAM)
    Set wiringProcessorFactory = New ClsWiringProcessorFactory
    
    Set workingSheet = wiringProcessorFactory.Process(workingSheet, wiringDiagramSheet, cellValuesList, columnMappingList, maxNumberOfRowsPerSheet)

    clsCommon.SetBasicColumnsHeaderText workingSheet                                                             ' �۾� ��Ʈ, �⺻ Cell Header Text �� ����

    Set wiringProcessorFactory = Nothing                                                                         ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    Set wiringDiagramSheet = Nothing                                                                             ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    Set cellValues = Nothing                                                                                     ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    Set cellValuesList = Nothing                                                                                 ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    
    Set columnMapping = Nothing                                                                                  ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    Set columnMappingList = Nothing                                                                              ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    
    Set ioSheetCell = Nothing                                                                                    ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    Set workingSheetCell = Nothing                                                                               ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    
    Set ioSheetColumnData = Nothing                                                                              ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    Set ioSheetFirstRow = Nothing                                                                                ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    Set ioSheetDataSheet = Nothing                                                                               ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    Set ioSheetWorkBook = Nothing                                                                                ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    Set workingSheetFirstRow = Nothing                                                                           ' ��ü����(��) �ʱ�ȭ(�޸� ����)
    Set clsCommon = Nothing                                                                                      ' ��ü����(��) �ʱ�ȭ(�޸� ����)

End Sub

