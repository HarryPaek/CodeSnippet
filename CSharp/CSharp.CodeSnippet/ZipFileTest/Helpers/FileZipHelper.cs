using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileTest.Helpers
{
    public static class FileZipHelper
    {
        /// <summary>
        /// 주어진 폴더를 폴더 이름으로 압축함
        /// - 따라서 압축 파일에는 별도 경로 없이 파일만 존재함
        /// - 만약 내부에 하위 폴더가 있다면 그대로 포함됨
        /// </summary>
        /// <param name="targetFolder">압축 대상 폴더</param>
        /// <returns></returns>
        public static string Zip(string targetFolder)
        {
            #region Parameter Validation

            if (string.IsNullOrWhiteSpace(targetFolder))
                throw new ArgumentNullException(nameof(targetFolder));

            if (!Directory.Exists(targetFolder))
                throw new ArgumentException("FORMATTER_FOLDER_NOT_EXIST_ERROR {0}", Path.GetFileName(targetFolder));

            #endregion

            string targetZipFile = string.Format("{0}.zip", targetFolder);

            ZipFile.CreateFromDirectory(targetFolder, targetZipFile);

            return targetZipFile;
        }

        /// <summary>
        /// 주어진 앞축 파일을 지정 폴더에 압축 파일 이름으로 폴더를 만들고 해제함
        /// - 해제된 경로는 "targetFolder\{압축파일이름}\압축 파일 내부 파일" 형식이 됨
        /// - 내부에 하위 폴더가 있다면, 하위 폴더로 그대로 해제됨
        /// </summary>
        /// <param name="targetFile">Zip 파일</param>
        /// <param name="targetFolder">압축 해제 폴더</param>
        /// <returns></returns>
        public static string UpZip(string targetFile, string targetFolder)
        {
            string unZipFolder = Path.Combine(targetFolder, Path.GetFileNameWithoutExtension(targetFile));

            ZipFile.ExtractToDirectory(targetFile, unZipFolder);

            return unZipFolder;
        }
    }
}
