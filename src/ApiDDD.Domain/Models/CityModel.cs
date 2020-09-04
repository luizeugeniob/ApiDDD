using System;

namespace ApiDDD.Domain.Models
{
    public class CityModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _ibgeCode;
        public int IBGECode
        {
            get { return _ibgeCode; }
            set { _ibgeCode = value; }
        }

        private Guid _stateId;
        public Guid StateId
        {
            get { return _stateId; }
            set { _stateId = value; }
        }
    }
}
