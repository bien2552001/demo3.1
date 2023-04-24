using BACKEND.Entities.DTO.DataDto.DTSU666;
using BACKEND.Entities.Model.Data_Mo.DTSU666;
using BACKEND.Interface.IData.IDTSU666;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using BACKEND.Interface.IData.IPZEM017;
using BACKEND.Entities.Model.Data_Mo.PZEM017;
using BACKEND.Entities.DTO.DataDto.PZEM017;
using NLog.Filters;
using System.Globalization;

namespace BACKEND.Repository.Data_Re
{
    public class PZEM017_Repository : IPZEM017_Repository
    {
        private const string databaseName = "PZEM017";   // Thuộc tính tên cơ sở dữ liệu 

        private const string collectionName = "Data_Pzem017"; // Thuộc tính tên của bộ sưu tập 

        private readonly FilterDefinitionBuilder<PZEM017_Model> filterBuilder = Builders<PZEM017_Model>.Filter; // Thuộc tính bộ lọc 

        private readonly IMongoCollection<PZEM017_Model> pzemCollection; // Tạo bộ sưu tập từ lớp Item

        public PZEM017_Repository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName); // Tham chiếu đến tên cơ sở dữ liệu 

            pzemCollection = database.GetCollection<PZEM017_Model>(collectionName);// Tham chiếu đến tên bộ sưu tập 

        }
   

        public async Task CreateAsync(PZEM017_Model data)
        {
            await pzemCollection.InsertOneAsync(data);
        }



        public async Task<IEnumerable<PZEM017_Model>> GetAllAsync(PZEM017_DataShapping_Dto repuestShapping, PZEM017_FillterTime_Dto fillter)
        {
            var builder = Builders<PZEM017_Model>.Filter;

            var filter = builder.Empty;

            if (fillter.FormattedStart != null)
            {
                filter &= builder.Gte("FormattedDate", fillter.FormattedStart);
            }

            if (fillter.FormattedEnd != null)
            {
                filter &= builder.Lte("FormattedDate", fillter.FormattedEnd);
            }

            return await Task.FromResult(pzemCollection.Find(filter).ToList());
        }


        //public async Task<PZEM017_Model> GetAsync(Guid id)
        //{
        //    var filter = filterBuilder.Eq(item => item.Id, id); // Id phải khớp với Id nhận được từ tham số 
        //    return await pzemCollection.Find(filter).SingleOrDefaultAsync(); // Phương thức SingleorDefult chỉ cho phép trả về 1 dữ liệu bất kì tìm thấy 
        //}

        //public async Task<IEnumerable<PZEM017_Model>> GetAllAsync(PZEM017_DataShapping_Dto requestShapping, PZEM017_FillterTime_Dto filter)
        //{
        //    var builder = Builders<PZEM017_Model>.Filter;
        //    var filterCondition = builder.Empty;

        //    if (filter.Start != null)
        //    {
        //        filterCondition &= builder.Gte(x => x.Date, filter.Start);
        //    }

        //    if (filter.End != null)
        //    {
        //        filterCondition &= builder.Lte(x => x.Date, filter.End);
        //    }

        //    var sort = Builders<PZEM017_Model>.Sort.Descending(x => x.Date);

        //    var query = pzemCollection.Find(filterCondition);


        //    var result = await query.Sort(sort).ToListAsync();

        //    return result;
        //}






        //public async Task DeleteAsync(Guid id)
        //{
        //    var filter = filterBuilder.Eq(item => item.Id, id); // Lọc theo Id
        //    await pzemCollection.DeleteOneAsync(filter); // Mỗi lần thực thi sẽ xóa theo id truyền vào 
        //}



        //public async Task UpdateAsync(PZEM017_Model data)
        //{
        //    var filter = filterBuilder.Eq(exsitingItem => exsitingItem.Id, data.Id); // Lọc theo id 
        //    await pzemCollection.ReplaceOneAsync(filter, data);
        //}

        //-----------------------------------------------------------------------------------------------------------
        //   public List<PZEM017_Model> GetSensorDataByHour(int hour)
        // {
        //     var filter = Builders<PZEM017_Model>.Filter.Eq(x => x.Timestamp.Hour, hour);
        //     return pzemCollection.Find(filter).ToList();
        // }



        // public List<PZEM017_Model> GetSensorDataByMonth(int month, int year)
        // {
        //     var filter = Builders<PZEM017_Model>.Filter.Eq(x => x.Timestamp.Month, month) & Builders<PZEM017_Model>.Filter.Eq(x => x.Timestamp.Year, year);
        //     return pzemCollection.Find(filter).ToList();
        // }

        // public List<PZEM017_Model> GetSensorDataByYear(int year)
        // {
        //     var filter = Builders<PZEM017_Model>.Filter.Eq(x => x.Timestamp.Year, year);
        //     return pzemCollection.Find(filter).ToList();
        // }


        ////------------DataSensor----------------------
        //public async Task<IEnumerable<PZEM017_Model>> GetSensorDataByDay(DateTime date)
        //{
        //    var startOfDay = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        //    var endOfDay = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        //    var filter = Builders<PZEM017_Model>.Filter.Gte(x => x.Timestamp, startOfDay) & Builders<PZEM017_Model>.Filter.Lte(x => x.Timestamp, endOfDay);
        //    return await Task.FromResult(pzemCollection.Find(filter).ToList());

        //}


        //public async Task Create1Async(PZEM017_Model data)
        //{
        //    await pzemCollection.InsertOneAsync(data);
        //}

        ////-------------------------------------------------------------------------------




    }
}
