using OOPSample.Entitys;
using OOPSample.Interfaces;

namespace OOPSample.DeparmentBuilders
{
    internal abstract class DepartmentBuilder : IDepartmentBuilder
    {
        public abstract string Name { get; protected set; }
        
        protected IRepository<Product> _repository;

        protected DepartmentBuilder(IRepository<Product> repository) =>        
            _repository = repository is not null ? repository : throw new ArgumentNullException();

        public abstract List<SellerConsultant> BuildConsultants();
        public abstract List<string> BuildEquipment();
        public abstract WareHouse BuildWareHouse();

        public StoreDepartment Build() => new StoreDepartment(Name, BuildConsultants(), BuildEquipment(), BuildWareHouse());
    }
}
