namespace PAB.Objects
{
    public class Setting
    {
        #pragma warning disable IDE1006 // 명명 스타일
        public Setting()
        {
            fontName = Properties.Settings.Default["fontName"].ToString();
            musicFontSize = Properties.Settings.Default["musicFontSize"].ToString();
            bibleFontSize = Properties.Settings.Default["bibleFontSize"].ToString();
            backgoundFilePath = Properties.Settings.Default["backgoundFilePath"].ToString();
            churchName = Properties.Settings.Default["churchName"].ToString();
            
            string usePptSetting = Properties.Settings.Default["usePowerPoint"]?.ToString();
            if (string.IsNullOrEmpty(usePptSetting) || usePptSetting == "True")
            {
                usePowerPoint = true;
            }
            else
            {
                usePowerPoint = bool.Parse(usePptSetting);
            }
        }

        private string _fontName { get; set; } = "HY견명조";
        public string fontName
        {
            get
            {
                return _fontName;
            }
            set
            {
                _fontName = value;
                Properties.Settings.Default["fontName"] = _fontName;
                Properties.Settings.Default.Save();
            }
        }

        private int _musicFontSize = 64;
        public string musicFontSize
        {
            get
            {
                return _musicFontSize.ToString();
            }
            set
            {
                string result = "";
                foreach (char eachWord in value)
                {
                    if (48 <= eachWord && eachWord <= 57) //numberic or letter check
                    {
                        result += eachWord;
                    }
                }
                _musicFontSize = int.Parse(result);
                Properties.Settings.Default["musicFontSize"] = _musicFontSize;
                Properties.Settings.Default.Save();
            }
        }

        private int _bibleFontSize = 64;
        public string bibleFontSize
        {
            get
            {
                return _bibleFontSize.ToString();
            }
            set
            {
                string result = "";
                foreach (char eachWord in value)
                {
                    if (48 <= eachWord && eachWord <= 57) //numberic or letter check
                    {
                        result += eachWord;
                    }
                }
                _bibleFontSize = int.Parse(result);
                Properties.Settings.Default["bibleFontSize"] = _bibleFontSize;
                Properties.Settings.Default.Save();
            }
        }

        private string _backgoundFilePath = "파일 선택";
        public string backgoundFilePath {
            get
            {
                return _backgoundFilePath;
            }
            set
            {
                if(value == string.Empty)
                {
                    _backgoundFilePath = "파일 선택";
                }
                else
                {
                    _backgoundFilePath = value;
                }
                Properties.Settings.Default["backgoundFilePath"] = _backgoundFilePath;
                Properties.Settings.Default.Save();
            }
        }

        private string _productionKey { get; set; }
        public string productionKey
        {
            get
            {
                return _productionKey;
            }
            set
            {
                _productionKey = value;
                Properties.Settings.Default["productionKey"] = _productionKey;
                Properties.Settings.Default.Save();
            }
        }

        private string _churchName { get; set; }
        public string churchName
        {
            get
            {
                return _churchName;
            }
            set
            {
                _churchName = value;
                Properties.Settings.Default["churchName"] = _churchName;
                Properties.Settings.Default.Save();
            }
        }

        private bool _usePowerPoint = true;
        public bool usePowerPoint
        {
            get
            {
                return _usePowerPoint;
            }
            set
            {
                _usePowerPoint = value;
                Properties.Settings.Default["usePowerPoint"] = _usePowerPoint;
                Properties.Settings.Default.Save();
            }
        }
    }
    #pragma warning restore IDE1006 // 명명 스타일
}
