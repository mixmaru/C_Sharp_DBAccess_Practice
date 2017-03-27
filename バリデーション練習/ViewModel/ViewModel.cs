using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace バリデーション練習.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            this.PersonList = new List<Person>();

            this.Load();
        }

        public List<Person> PersonList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Load()
        {
            this.PersonList.Add(new Person()
            {
                Name = "桜井 章",
                Age = 20,
            });
            this.PersonList.Add(new Person()
            {
                Name = "草薙剛",
                Age = 40,
            });
        }
    }
}
