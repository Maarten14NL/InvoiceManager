using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager_Logic
{
    public class PlaceHolder
    {
        private readonly string _placeHolder;
        private readonly string _newValue;

        public PlaceHolder(string placeHolder, string newValue)
        {
            _placeHolder = placeHolder;
            _newValue = newValue;
        }
        public string Placeholder
        {
            get
            {
                return _placeHolder;
            }
        }

        public string NewValue { 
            get
            {
                return _newValue;
            }
        }


    }
}
