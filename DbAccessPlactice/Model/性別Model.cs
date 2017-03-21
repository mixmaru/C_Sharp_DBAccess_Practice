using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccessPlactice.Model
{
    static class 性別Model
    {

        private static List<性別取得Entity> _性別取得entityList;
        public static List<性別取得Entity> 性別取得entityList
        {
            get { return _性別取得entityList; }
        }

        static 性別Model()
        {
            _性別取得entityList = new List<性別取得Entity>();
            _性別取得entityList.Add(new 性別取得Entity()
            {
                ID = 1,
                name = "男",
            });
            _性別取得entityList.Add(new 性別取得Entity()
            {
                ID = 2,
                name = "女",
            });
        }
    }

    public class 性別取得Entity
    {
        public int ID { get; set; }
        public string name { get; set; }
    }

}
