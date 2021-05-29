using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGeneratorCSharp
{
    class CreateFileName
    {
        
        private string _FilePrefix;
        private string _ShortName;
        private string _FileSufix;
        private string _FileExt;
        private string _NewFileName;

        public string MidFileName = "";

        public string FilePrefix { get; set;}
        public string FileSufix { get; set; }
        public string FileExt { get; set; }
        public string NewFileName
        {
            get { return _NewFileName; }
            private set { _NewFileName = value; }
        }

        public CreateFileName()
        {
            _FilePrefix = "pref_";
            _FileSufix = "_sufx";
            _FileExt = "ext";
        }

        public void GenerateNewFileName()
        {
            _ShortName = GenerateShorName();
            _NewFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            _NewFileName = _FilePrefix + _ShortName + _NewFileName + _FileSufix + "." + _FileExt;
            this.NewFileName = _NewFileName;
        }

        private string GenerateShorName()
        {
            string AllowedCharacters = "1234567890abcdefghijklmnoprstuwxyz";
            string shortN = "";
            string testChar = "";

            for (int lpL=0; lpL< MidFileName.Length ; lpL++)
            {
                testChar = MidFileName.Substring(lpL, 1);
                if (AllowedCharacters.IndexOf(testChar.ToLower()) > 0)
                    shortN += testChar;
            }

            return shortN;
        }
    }
}
