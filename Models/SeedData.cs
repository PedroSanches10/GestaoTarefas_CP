using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas_CP.Models
{
        public static class SeedData
        {
            private const string PEDRO_ROLE = "pedr";
            private const string CARINA_ROLE = "cari";

            public static void Populate(TarefasDbContext db)
            {
                PopulateProfessor(db);
                PopulateFuncionario(db);

            }

            private static void PopulateProfessor(TarefasDbContext db)
            {
                if (db.Professor.Any()) return;

                db.Professor.AddRange(
                    new Professor { Nome = "Professor", Telemovel="914009710", Email="pedrosanches10@gmail.com", Gabinete="32", Disciplina="Gestão" },
                    new Professor { Nome = "Professor", Telemovel = "914009710", Email = "pedrosanches10@gmail.com", Gabinete = "32", Disciplina = "Gestão" },
                    new Professor { Nome = "Professor", Telemovel = "914009710", Email = "pedrosanches10@gmail.com", Gabinete = "32", Disciplina = "Gestão" },
                    new Professor { Nome = "Professor", Telemovel = "914009710", Email = "pedrosanches10@gmail.com", Gabinete = "32", Disciplina = "Gestão" }
                );
            db.SaveChanges();
            }

            private static void PopulateFuncionario(TarefasDbContext db)
            {
                if (db.Funcionario.Any()) return;

                db.Funcionario.AddRange(
                    new Funcionario { Nome = "Carlos Lopes", Morada="Avenida de Liberdade", Numero="1012180", Escola="ESTG", Email="pedro@gmail.com", Telemovel="914009888", NIF="250114585" },
                    new Funcionario { Nome = "Barbara Teixeira", Morada = "Rua Espirito Santo", Numero = "1012164", Escola = "ESTG", Email = "barbara@gmail.com", Telemovel = "914009785", NIF = "250114580" },
                    new Funcionario { Nome = "Carolina Pinto", Morada = "Avenida Alterto Torres", Numero = "1002006", Escola = "ESTG", Email = "carolina@gmail.com", Telemovel = "914009756", NIF = "500114525" },
                    new Funcionario { Nome = "Cátia Esteves", Morada = "Travessa Castro", Numero = "1023566", Escola = "ESTG", Email = "catia@gmail.com", Telemovel = "914009785", NIF = "250114852" }
                );

                db.SaveChanges();
            }
       

            ////////////User Login
            public static async Task PopulateUsersAsync(UserManager<IdentityUser> userManager)  //names
            {
                const string PEDRO_USERNAME = "pedro@ipg.pt";
                const string PEDRO_PASSWORD = "Secret123$";

                const string CARINA_USERNAME = "carina@ipg.pt";
                const string CARINA_PASSWORD = "Secret123$";


                IdentityUser user = await userManager.FindByNameAsync(PEDRO_USERNAME);//await -esperar
                if (user == null)
                {
                    user = new IdentityUser
                    {
                        UserName = PEDRO_USERNAME,
                        Email = PEDRO_USERNAME
                    };

                    await userManager.CreateAsync(user, PEDRO_PASSWORD);
                }

                if (!await userManager.IsInRoleAsync(user, PEDRO_ROLE))
                {
                    await userManager.AddToRoleAsync(user, PEDRO_ROLE);
                }

                user = await userManager.FindByNameAsync(PEDRO_USERNAME);



                user = await userManager.FindByNameAsync(CARINA_USERNAME);

                if (user == null)
                {
                    user = new IdentityUser
                    {
                        UserName = CARINA_USERNAME,
                        Email = CARINA_USERNAME
                    };

                    await userManager.CreateAsync(user, CARINA_PASSWORD);
                }

                if (!await userManager.IsInRoleAsync(user, CARINA_ROLE))
                {
                    await userManager.AddToRoleAsync(user, CARINA_ROLE);
                }
            }

            public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
            {


                if (!await roleManager.RoleExistsAsync(PEDRO_ROLE))
                {
                    await roleManager.CreateAsync(new IdentityRole(PEDRO_ROLE));
                }

                if (!await roleManager.RoleExistsAsync(CARINA_ROLE))
                {
                    await roleManager.CreateAsync(new IdentityRole(CARINA_ROLE));
                }
            }


        }
    }



