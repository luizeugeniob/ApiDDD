using System;

namespace ApiDDD.Domain.Models
{
    public class AddressModel : BaseModel
    {
        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        private string _streed;
        public string Street
        {
            get { return _streed; }
            set { _streed = value; }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set { _number = string.IsNullOrEmpty(value) ? "S/N" : value; }
        }

        private Guid _cityId;
        public Guid CityId
        {
            get { return _cityId; }
            set { _cityId = value; }
        }
    }
}
