namespace DataAccessQueries
{
    public class baseDataAccess
    {

        public bool IsErr
        {
            get { if (_ErrorMsg == string.Empty) return false; else return true; }
        }

        private string _ErrorMsg; // In place of error loggging  & some sort error error message to calling method
        public string ErrorMsg { get { return _ErrorMsg; } internal set { _ErrorMsg = value; } }

    }
}
