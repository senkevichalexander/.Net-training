using System;

namespace BLL
{
    public class GuidGenerator
    {
        private static GuidGenerator _instance;
        public Guid GenerateNewGuid()
        {
            return Guid.NewGuid();
        }

        public static GuidGenerator GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GuidGenerator();
            }

            return _instance;
        }
    }
}
