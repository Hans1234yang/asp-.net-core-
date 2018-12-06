using DemoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yangxu1.Service
{
    public class CinemaMemoryService:ICinemaService
    {
        //内存中的数据源
        private readonly List<Cinema> _cinemas = new List<Cinema>();

        public CinemaMemoryService()
        {
            _cinemas.Add(new Cinema
            { 
                Id=1,                 //对象初始化器
                Name ="城市电影院",
                Location="福田区",
                Capacity = 1000
            });

            _cinemas.Add(new Cinema
            {
                Id=2,
                Name="飞翔电影院",
                Location="罗湖区",
                Capacity = 500
            });
        }

        public Task AddAsync(Cinema model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return Task.Run(() => _cinemas.AsEnumerable());
        }

        public Task<Cinema> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
