
using ClassLibrary1.DataAccess;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Repository
{
    public class FlowerRepository : IFlowerRepository

    {
        public bool DeleteFlower(FlowerBouquet flowerBouquet) => FlowerManagement.Instance.Remmove(flowerBouquet);

        public FlowerBouquet GetFlowerBouquetById(int? id)
        {
            return FlowerManagement.Instance.GetFlowerByFlID(id);
        }

        public List<FlowerBouquet> GetFlowerBouquets()
        {
            return FlowerManagement.Instance.GetFlowerBouquets();
        }

        public List<FlowerBouquet> GetFlowerBouquetsByName(string name)
        {
            return FlowerManagement.Instance.GetFlowerBouquetsByName(name);
        }

        public List<FlowerBouquet> GetFlowerBouquetsByStatus()
        {
            return FlowerManagement.Instance.GetFlowerBouquetsByStatus();   
        }

        public List<FlowerBouquet> GetFlowerBouquetsByStatusAndStock()
        {
            return FlowerManagement.Instance.GetFlowerBouquetsByStatusAndStock();
        }

        public List<FlowerBouquet> GetFlowerByCateIdAndStatus(int cateId)
        {
            return FlowerManagement.Instance.GetFlowerByCateIdAndStatus(cateId); 
        }

        public FlowerBouquet GetObjetByFlId(FlowerBouquet flowerBouquet)
        {
            return FlowerManagement.Instance.GetFlowerByFlID(flowerBouquet);
        }

        public void InserFlower(FlowerBouquet flowerBouquet) => FlowerManagement.Instance.AddNew(flowerBouquet);

        public void Update(FlowerBouquet flowerBouquet) => FlowerManagement.Instance.Update(flowerBouquet);

    }
}
