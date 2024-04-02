//using ecommerce.domain.entities;
//using ecommerce.domain.enums;
//using microsoft.aspnetcore.ıdentity;
//using system;
//using system.collections.generic;
//using system.linq;
//using system.text;
//using system.threading.tasks;

//namespace ecommerce.ınfrastructure.seeddata
//{
//    public static class appuserseeddata
//    {        
//        public static void seedusers(this usermanager<appuser> _usermanager, rolemanager<ıdentityrole> _rolemanager)
//        {            
            
//                var roles = new list<ıdentityrole>
//                {
//                    new ıdentityrole { name = "admin" },
//                    new ıdentityrole { name = "user" }
//                };

//                foreach (var role in roles)
//                {
//                    _rolemanager.createasync(role).getawaiter().getresult();
//                }
            

//            if (_usermanager.findbyemailasync("admin@example.com").getawaiter().getresult() == null)
//            {
//                var adminuser = new appuser
//                {
//                    firstname = "admin",
//                    lastname = "user",
//                    username = "admin@example.com",
//                    email = "admin@example.com",
//                    address = "admin address",
//                    createdate = datetime.now,
//                    status = status.active
//                };

//                _usermanager.createasync(adminuser, "admin123").getawaiter().getresult();
//                _usermanager.addtoroleasync(adminuser, "admin").getawaiter().getresult();
//            }

//            if (_usermanager.findbyemailasync("user@example.com").getawaiter().getresult() == null)
//            {
//                var regularuser = new appuser
//                {
//                    firstname = "regular",
//                    lastname = "user",
//                    username = "user@example.com",
//                    email = "user@example.com",
//                    address = "user address",
//                    createdate = datetime.now,
//                    status = status.active
//                };

//                _usermanager.createasync(regularuser, "user123").getawaiter().getresult();
//                _usermanager.addtoroleasync(regularuser, "user").getawaiter().getresult();
//            }

//        }
//    }
//}
