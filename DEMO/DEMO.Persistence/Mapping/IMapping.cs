using Microsoft.EntityFrameworkCore;

namespace DEMO.Persistence.Mapping;

public interface IMapping
{
	void ApplyConfiguration(ModelBuilder builder);
}