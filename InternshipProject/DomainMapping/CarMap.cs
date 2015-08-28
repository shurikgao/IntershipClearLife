using Domain.Domain;
using FluentNHibernate.Mapping;

namespace DomainMapping
{
    public class CarMap : EntityMap<Car>
    {
        public CarMap()
        {
            //Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.EngineVol).Not.Nullable();
            Map(x => x.TankVol).Not.Nullable();
            Map(x => x.BodyType).Not.Nullable();
            Map(x => x.CountryOfOrigin).Not.Nullable();
            HasMany(x => x.Drivers).Cascade.SaveUpdate().Inverse(); //.KeyColumn("DriverId");
        }
    }

    public class ChinaCarMap : SubclassMap<ChinaCar>
    {
        public ChinaCarMap()
        {
            Map(x => x.Originality);
        }
    }

    public class GermanyCarMap : SubclassMap<GermanyCar>
    {
        public GermanyCarMap()
        {
            Map(x => x.Prestige);
        }
    }

    public class JapanCarCarMap : SubclassMap<JapanCar>
    {
        public JapanCarCarMap()
        {
            Map(x => x.Safety);
        }
    }
}