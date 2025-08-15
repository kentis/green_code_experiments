
package battle_of_json_parsers;
import com.fasterxml.jackson.databind.ObjectMapper;
import java.io.File;
import java.io.IOException;
import java.time.Duration;
import java.time.Instant;
import com.google.gson.Gson;



public class JsonParseBenchmark {

    public static long testGson(String fileName) {
        File jsonFile = new File(fileName);
        Gson gson = new Gson();

        try {
            // Warm up JVM
            // for (int i = 0; i < 10; i++) {
            //     gson.fromJson(new FileReader(jsonFile), Object.class);
            // }

            Instant start = Instant.now();
            for(int i = 0; i < 10; i++) {
                gson.fromJson(new java.io.FileReader(jsonFile), Object.class);
            }
            
            Instant end = Instant.now();

            Duration duration = Duration.between(start, end);
            System.out.println("Time to parse JSON with Gson: " + duration.toMillis() + " ms");
            return duration.toMillis();
        } catch (IOException e) {
            System.err.println("Failed to parse JSON: " + e.getMessage());
        }
        return -1; // Return -1 in case of failure
    }

    public static long testJackson(String fileName) {
        File jsonFile = new File(fileName);
        ObjectMapper mapper = new ObjectMapper();

        try {
            // Warm up JVM
            // for (int i = 0; i < 10; i++) {
            //     mapper.readTree(jsonFile);
            // }

            Instant start = Instant.now();
            for(int i = 0; i < 10; i++) {
                mapper.readTree(jsonFile);
            }
            
            Instant end = Instant.now();

            Duration duration = Duration.between(start, end);
            System.out.println("Time to parse JSON with Jackson: " + duration.toMillis() + " ms");
            return duration.toMillis();
        } catch (IOException e) {
            System.err.println("Failed to parse JSON: " + e.getMessage());
        }
        return -1; // Return -1 in case of failure
    }

    public static void main(String[] args) {

        String fileName = "../data/data_1k.json";
        long timeTakenGson = testGson(fileName);
        //long timeTaken = testJackson(fileName);

        
        //System.out.println("Time taken to parse JSON: " + timeTaken + " ms");
        
    }
}
