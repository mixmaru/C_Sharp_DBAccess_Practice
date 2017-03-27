using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace バリデーション練習.ViewModel
{
    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _Name;
        public string Name 
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        private int _Age;
        public int Age
        {
            get
            {
                return this._Age;
            }
            set
            {
                this._Age = value;
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Age"));
                }
            }
        }
    }
}
