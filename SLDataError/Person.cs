using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDataError
{
    class Person : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        // FullNameプロパティにエラーがあるかないか
        private bool _hasFullNameError;

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                // 空はだめよ
                _hasFullNameError = string.IsNullOrWhiteSpace(_fullName);
                // FullNameプロパティのエラー事情に変化があったことを通知
                OnErrorsChanged("FullName");
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessages"));
                }
            }
        }

        public IEnumerable ErrorMessages
        {
            get
            {
                return this.GetErrors("FullName");
            }
        }

        #region INotifyDataErrorInfo Members

        public event System.EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        // ErrorsChangedイベントを発行する
        private void OnErrorsChanged(string propertyName)
        {
            var h = ErrorsChanged;
            if (h != null)
            {
                h(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            // FullNameプロパティでエラーがあったら
            if (propertyName == "FullName" && _hasFullNameError)
            {
                // エラーの内容を返す
                return new[] { "名前には、何か入れてね♪" };
            }

            // それ以外は、何もなし
            return null;
        }

        // なんかエラーがあったらtrue
        public bool HasErrors
        {
            get { return _hasFullNameError; }
        }

        #endregion
        /*
        //FullNameプロパティにエラーがあるかないか
        private bool _hasFullNameError;

        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                //空はだめよ
                this._hasFullNameError = string.IsNullOrWhiteSpace(_fullName);
                // FUllNameプロパティのエラー事情に変化があったことを通知
                this.OnErrorsChanged("FullName");
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private void OnErrorsChanged(string propertyName)
        {
            var h = ErrorsChanged;
            if (h != null)
            {
                h(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            // FullNameプロパティでエラーがあったら
            if(propertyName == "FullName" && this._hasFullNameError)
            {
                return new[] { "名前には、何か入れてね" };
            }

            //それ以外は、何もなし
            return null;
        }

        public bool HasErrors
        {
            get
            {
                return this._hasFullNameError;
            }
        }
        */
    }
}
