package com.db.pdi;

import org.flywaydb.core.Flyway;
import org.flywaydb.core.api.Location;

public class Main {
    public static void main(String[] args) {
        String connectionUrlflyway = "jdbc:sqlserver://localhost:1433;databaseName=TestDB;trustServerCertificate=true";

        Location sqlServerLocation = new Location("filesystem:migracoes/db/sqlserver");

        Flyway flyway = Flyway.configure()
                              .dataSource(connectionUrlflyway
                              , "sa"
                              , "Sap@12345")
                              .locations(new Location[] { sqlServerLocation })
                              .load();

        flyway.migrate();
    }
}