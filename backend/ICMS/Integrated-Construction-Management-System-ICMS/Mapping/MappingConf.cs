namespace Integrated_Construction_Management_System_ICMS.Mapping
{
    public class MappingConf : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ApplicationUser, AddMembersRequest>()
           .Map(dest => dest.PermissionNumber, src => src.PasswordHash);

            config.NewConfig<ApplicationUser, LoginMemberRequest>()
         .Map(dest => dest.PermissionNumber, src => src.PasswordHash);
        }
    }
}
