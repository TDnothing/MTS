package MTS;

public class Main {

    public static void main(String[] args) {
        String scenarioFile = args[0];

        try {
            Simulation simulation = new Simulation();
            simulation.CreateSimulation(scenarioFile);

        } catch (Exception e) {
            e.printStackTrace();
            System.out.println();
        }
    }
}