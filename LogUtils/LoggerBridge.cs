namespace LogUtils
{
    public class LoggerBridge
    {
        private static readonly LoggerBridge Instance = new LoggerBridge();

        private bool _hasCoppied;

        private string _pathLog4Net;

        private LoggerBridge()
        {
            _hasCoppied = false;
        }

        public static LoggerBridge GetInstance()
        {
            return Instance;
        }

        public void SetPath(string path)
        {
            if (_hasCoppied) return;
            lock (this)
            {
                _pathLog4Net = path;
                _hasCoppied = true;
            }
        }

        public string GetPath()
        {
            return _pathLog4Net;
        }
    }
}
