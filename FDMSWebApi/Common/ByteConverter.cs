namespace FDMSWebApi.Common
{
    public class ByteConverterTest
    {
        public byte[] GetImageToByteArray(string path)
        {
            byte[] imageArray = File.ReadAllBytes(path);
            return imageArray;
        }
    }
}
