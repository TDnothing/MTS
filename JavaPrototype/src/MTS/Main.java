package MTS;

import java.util.Scanner;
import java.io.File;

public class Main {

    public static void main(String[] args) {
        final String DELIMITER = ",";
        String scenarioFile = args[0];

        try {
            Scanner takeCommand = new Scanner(new File(scenarioFile));
            String[] tokens;

            do {
                String userCommandLine = takeCommand.nextLine();
                tokens = userCommandLine.split(DELIMITER);
                System.out.print(tokens[0]);

                switch (tokens[0]) {
                    case "add_depot":
                        System.out.println(", <ID>:" + tokens[1] + ", <Name>:" + tokens[2] + ", <X-Coord>:" + tokens[3] + ", <Y-Coord>:" + tokens[4]);
                        break;
                    case "add_stop":
                        System.out.println(", <ID>:" + tokens[1] + ", <Name>:" + tokens[2] + ", <Riders>:" + tokens[3] + ", <Latitude>:" + tokens[4] + ", <Longitude>:" + tokens[5]);
                        break;
                    case "add_route":
                        System.out.println(", <ID>:" + tokens[1] + ", <Number>:" + tokens[2] + ", <Name>:" + tokens[3]);
                        break;
                    case "extend_route":
                        System.out.println(", <Route ID>:" + tokens[1] + ", <Stop ID>:" + tokens[2]);
                        break;
                    case "add_bus":
                        System.out.println(", <ID>:" + tokens[1] + ", <Route>:" + tokens[2] + ", <Location>:" + tokens[3] + ", <Initial Passengers>:" + tokens[4] + ", <Passenger Capacity>:" + tokens[5] + ", <Initial Fuel>:" + tokens[6] + ", <Fuel Capacity>:" + tokens[7] + ", <Speed>:" + tokens[8]);
                        break;
                    case "add_event":
                        System.out.println(", <Time>:" + tokens[1] + ", <Type>:" + tokens[2] + ", <ID>:" + tokens[3]);
                        break;
                    default:
                        System.out.println(" command not recognized");
                        break;
                }
            } while (takeCommand.hasNextLine());

            takeCommand.close();
        } catch (Exception e) {
            e.printStackTrace();
            System.out.println();
        }
    }
}