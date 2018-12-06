using System;

namespace DemoModel
{
    /// <summary>
    /// 电影院类
    /// </summary>
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set;}

        public string Location { get; set; }
        //最大观众容量
        public int Capacity { get; set; }
    }
}
