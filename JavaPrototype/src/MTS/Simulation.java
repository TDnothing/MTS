package MTS;
import java.io.FileNotFoundException;
import java.util.Scanner;
import java.io.File;
public class Simulation {

    public void CreateSimulation(String scenarioFile) throws FileNotFoundException {
        Scanner takeCommand = new Scanner(new File(scenarioFile));
        ReadFile(takeCommand);
        for (int i = 0; (i < 20); i++) {
            MoveNextBusButtonClick();
        }

    }

    private void ReadFile(Scanner takeCommand) {
        final String DELIMITER = ",";
        String[] tokens;
        do {
            String userCommandLine = takeCommand.nextLine();
            tokens = userCommandLine.split(DELIMITER);
            BusSystem.CreateObject(tokens);


        } while (takeCommand.hasNextLine());

        takeCommand.close();
    }
    public void MoveNextBusButtonClick()
    {
        BusSystem.MoveNextBus();
    }
}
