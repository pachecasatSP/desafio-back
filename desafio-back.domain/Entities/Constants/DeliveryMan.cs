namespace desafio_back.domain.Entities.Constants
{
    public class CNHTypes
    {
        private static List<string> _acceptedTypes = [A, B, AB];

        public const string A = "A";
        public const string B = "B";
        public const string AB = "AB";

        public static Task<List<string>> GetListAsync() => Task.FromResult(_acceptedTypes);
        public static Task<bool> IsAccepted(string cnhType) => Task.FromResult(_acceptedTypes.Contains(cnhType));
    }

    public class AcceptedCNHImageFormats
    {
        public const string PNG = "PNG";
        public const string BMP = "BMP";

        public static async Task<List<string>> GetListAsync() => new List<string> { PNG, BMP };

        public static async Task<bool> IsAccepted(byte[] imageByteArray) =>
            PngImageFormat.VerifyHeader(imageByteArray) || BmpImageFormat.VerifyHeader(imageByteArray);

        public static async Task<string> GetFormatName(byte[] imageByteArray)
        {
            if (PngImageFormat.VerifyHeader(imageByteArray))
                return PNG;

            if (BmpImageFormat.VerifyHeader(imageByteArray))
                return BMP;

            throw new ArgumentException("Imagem nâo é de um formato permitido.");
        }

        public class PngImageFormat
        {
            private static readonly int _byteZero = 0x89;
            private static readonly int _byteOne = 0x50;
            private static readonly int _byteTwo = 0x4E;
            private static readonly int _byteThree = 0x47;

            public static bool VerifyHeader(byte[] bytes) =>
                bytes.Length > 3 &&
                bytes[0] == _byteZero &&
                bytes[1] == _byteOne &&
                bytes[2] == _byteTwo &&
                bytes[3] == _byteThree;
        }

        public class BmpImageFormat
        {
            private static readonly int _byteZero = 0x42;
            private static readonly int _byteOne = 0x4D;

            public static bool VerifyHeader(byte[] bytes) =>
                bytes.Length > 1 &&
                bytes[0] == _byteZero &&
                bytes[1] == _byteOne;
        }

    }
}
