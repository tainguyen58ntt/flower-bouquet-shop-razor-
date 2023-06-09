
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public interface IFlowerRepository
    {
        List<FlowerBouquet> GetFlowerBouquets();
        //Customer CheckLogin(string name, string password);

        
        ////Car GetCarByID(int id);
        void InserFlower(FlowerBouquet flowerBouquet);
        //void Update(Customer customer);
        bool DeleteFlower(FlowerBouquet flowerBouquet);
        FlowerBouquet GetObjetByFlId(FlowerBouquet flowerBouquet);

        FlowerBouquet GetFlowerBouquetById(int? id);
        void Update(FlowerBouquet flowerBouquet);
        List<FlowerBouquet> GetFlowerBouquetsByName(string name);


        List<FlowerBouquet> GetFlowerBouquetsByStatus();

        List<FlowerBouquet> GetFlowerByCateIdAndStatus(int cateId);  
    }
}
