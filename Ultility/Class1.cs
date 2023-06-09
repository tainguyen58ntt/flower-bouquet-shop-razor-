namespace Ultility
{
    public class Class1
    {

        public static int GenerateUniqueId()
        {
            var guid = Guid.NewGuid();

            var bytes = guid.ToByteArray();
            var uniqueId = BitConverter.ToInt32(bytes, 0);
            return uniqueId;
        }
    }
}