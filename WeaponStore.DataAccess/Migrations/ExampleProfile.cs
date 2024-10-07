using FluentMigrator;



namespace ExampleDatabaseMigrations

{

    [Migration(20241007174016)]

    public class ExampleProfile : Migration

    {

        public override void Up()

        {

            Create.Table("User");

        }



        public override void Down()

        {

            //empty, not used

        }

    }

}