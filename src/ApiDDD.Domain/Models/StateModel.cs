namespace ApiDDD.Domain.Models
{
    public class StateModel : BaseModel
    {
        private string _shortName;
        public string ShortName
        {
            get { return _shortName; }
            set { _shortName = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

    }
}
