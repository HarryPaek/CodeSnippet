using System.ComponentModel;

namespace EnumTestApp.AppClasses
{
    public enum LSCableDRMServiceReturnCode
    {
        [Description("알 수 없는 오류")]
        Unknown = -1,

        [Description("성공")]
        Success = 0,

        [Description("성공, 옛날 방식으로 암호화된 파일")]
        SuccessOldEncryptedFile = 1,

        [Description("성공, 암호화된 파일")]
        SuccessEncryptedFile = 2,

        [Description("이미 암호화 되어 있는 파일")]
        ErrorFileAlreadyEncrypted = 70001,

        [Description("파일 암호화 실패")]
        ErrorWhileEncryptingFile = 70002,

        [Description("파일 복원 시, 잘못된 Company ID")]
        ErrorInvalidCompanyId = 70004,

        [Description("암호화 된 파일 아님")]
        ErrorFileNotEncrypted = 70006,

        [Description("지원하는 파일 형식(확장자)가 아님")]
        ErrorNotSupportExtension = 70013,

        [Description("파일 복원 시, 잘못된 해시 값")]
        ErrorInvalidHashValue = 70020,

        [Description("해당 파일이 존재하지 않음")]
        ErrorFileNotFound = 70021,

        [Description("잘못된 라이선스 코드")]
        ErrorInvalidLicenseCode = 70056,

        [Description("지원/허용하는 프로그램이 아님")]
        ErrorNotSupportedApplication = 70060,

        [Description("지원하는 함수가 아니라 사용 못함")]
        ErrorNotSupportedFunction = 70061
    }
}
