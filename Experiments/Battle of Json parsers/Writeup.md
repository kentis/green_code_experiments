# Examining the performance of a selection of popular Json Parsers

JSON har become a defacto standard way of encoding data transfer on the web and beyond. It is so popular that it is safe to assume that a fair amount of internet traffic is at some point parsed as by a Json parser. While it is difficult to estimate the amount
of JSON data that is transmitted, or parsed, globally for any given time unit, it is safe to assume that the number is quite enormous. Thus, it would be prudent for application developers whose applications do process significant amounts of Json data to 
consider the time and energy efficiency of their chosen Json parser.

In this writeup I detail the results of an experiment pitting several Json parsers against each other paring the same random json data. Since the data is random and does not follow any set schema, the results may not be consistent with most applications out there. However, the results may tell us something about wether it can be worth it to experiment wth which Json parser you use and
to see if there are any significant differences between different ecosystems or of the differences are larger inside each ecosystem.

## Method

This study considers three popular platforms/ecosystems .Net, Python and Java. Furthermore, two popular ways to parse Json is considered for each. For Dotnet the built in `System.Text.Json` and `Newtonsoft.Json` are chosen. For Python, the `json` and `orjson`packages are studied. Finally, for Java `Jackson` and `Gson` parsers are included. Each parser is selected based on fast non-rigorous google searches, but still seem to be fairly popular choices. All parsees are tested by quite naive implementations. The code for all the experiments as well as all data can be found [here](https://github.com/kentis/green_code_experiments/blob/main/Experiments/Battle%20of%20Json%20parsers/code)

Each json parser is used to parse the same 3.3MB Json document 10 times. This is probably not representative for most Json documents, however, using a large documents makes measuring easier. The programs report the time spent in the loop. Additionally, each method was measured using the builtin `time` command to see the actual CPU use of the program.

## Results

| Platform | Parser           | Reported time | `time` User | `time` System |
| -------- | ---------------- | ------------- | ----------- | ------------- |
| Dotnet   | Newtonsoft.Json  |  1.7s         | 2.8s        |  0.3s        |
| Dotnet   | System.Text.Json |  0.3s         | 1.1s        |  0.2s        |
| Python   | json (std lib)   |  0.3s         | 0.3s        |  0.0s        |
| Python   | orjson           |  0.2s         | 0.2s        |  0.0s        |
| Java     | Jackson          |  0.7s         | 1.3s        |  0.1s        |
| Java     | Gson             |  0.2s         | 0.5s        |  0.1s        |


The results are shown in the table above. As we can see, the popular Newtonsoft.Json Json parser for dotnet was the the slowest option
followed by Javas Jackson. All other parsers seems to perform similarly to eachother with Pythons orjson and Javas Gson tying for the fastest options available for this particular case. 

Due to the surprising slowness and enormous popularity of Newtonsoft.Json and  Jackson parsers users of these libraries that parse lots of Json documents might be wise to do experiments that more closely resemble their use to see if they sould consider switching Json parser.


# Apendix 1: Raw results

```sh
dotNetNewtonSoft ✗ time dotnet run
NewtonSoft: 1689ms
dotnet run  2.81s user 0.26s system 105% cpu 2.901 total
```

```sh
dotNetSystemTextJson ✗ time dotnet run
System.Text.Json: 255ms
dotnet run  1.14s user 0.19s system 98% cpu 1.345 total
```

```sh
Python ✗ time python3 program.py
Average parsing time with json (stdlib): 0.028536 seconds. Total 0.285364 seconds.
python3 program.py  0.28s user 0.04s system 97% cpu 0.328 total
```

```sh
Python ✗ time python3 program.py
Average parsing time with orjson: 0.019182 seconds. Total 0.191822 seconds
python3 program.py  0.19s user 0.03s system 98% cpu 0.225 total
```

```sh
Java git:(cpu_time_for_asParalell) ✗ time java -jar target/battle_of_json_parsers-1.0.0-jar-with-dependencies.jar
Time to parse JSON with Jackson: 725 ms
java -jar target/battle_of_json_parsers-1.0.0-jar-with-dependencies.jar  1.31s user 0.08s system 156% cpu 0.889 total
```

```sh
Java git:(cpu_time_for_asParalell) ✗ time java -jar target/battle_of_json_parsers-1.0.0-jar-with-dependencies.jar
Time to parse JSON with Gson: 192 ms
java -jar target/battle_of_json_parsers-1.0.0-jar-with-dependencies.jar  0.47s user 0.06s system 178% cpu 0.297 total
```
