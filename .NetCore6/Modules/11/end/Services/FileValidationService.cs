
namespace Globomantics.Survey.Services
{
    public class FileValidationService
    {
        private static readonly Dictionary<string, List<byte[]>> _fileSignatures = new Dictionary<string, List<byte[]>>
        {
            { ".png", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
            { ".jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
        };

        public bool IsValid(IFormFile uploadedFile)
        {
            string ext = Path.GetExtension(uploadedFile.FileName);

            if (!_fileSignatures.ContainsKey(ext))
            {
                return false;
            }

            using (var reader = new BinaryReader(uploadedFile.OpenReadStream()))
            {
                var signatures = _fileSignatures[ext];
                var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

                return signatures.Any(signature => 
                    headerBytes.Take(signature.Length).SequenceEqual(signature));
            }
        }
    }
}