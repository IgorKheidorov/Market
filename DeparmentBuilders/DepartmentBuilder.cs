using OOPSample.Entitys;
using OOPSample.Interfaces;
using OOPSample.Repositories;

namespace OOPSample.DeparmentBuilders
{
    internal abstract class DepartmentBuilder : IDepartmentBuilder
    {
        public abstract string Name { get; protected set; }
        
        protected JSONRepository<Product> _repository;

        protected DepartmentBuilder(JSONRepository<Product> repository) =>        
            _repository = repository is not null ? repository : throw new ArgumentNullException();

        public abstract List<SellerConsultant> BuildConsultants();
        public abstract List<string> BuildEquipment();
        public abstract WareHouse BuildWareHouse();

        public StoreDepartment Build() => new StoreDepartment(Name, BuildConsultants(), BuildEquipment(), BuildWareHouse());
    }
}
