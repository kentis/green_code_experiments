# Parsing Dates in Java: Which was is faster?

For computers, dates can be really tricky things in a myriad of ways. One of these ways 
is when trying to read text and turn it into something that the software can even realize is a date.
Luckily, most programming languages have intricate solutions to solve this problem in
packages of standardized functions that are often called libraries.

The Java programming language is no exception. In fact, bundled with the language itself there are several ways to parse strings into Date objects. In this experiment we will parse 10000 dates by using each of the following classes:

* java.time.LocalDate
* java.time.LocalDateTime
* java.text.SimpleDateFormat

All the dates that are parsed in our experiment will have a format like "2025-01-25" or, more generally, "yyyy-MM-dd". We will then time how long it takes to complete parsing all 10000 dates with exch method using `System.nanoTime()`.

In order to run this experiment we need piece of software that parses a list of date strings that we generate in runtime and keep in memory. Then the program will parse the the dates in the list with each method while timing them.


After running this experiment 10 times on my Macbook M2 I got the following results:


|Run #|LocalDate (ms)|LocalDateTime (ms)|SimpleDateFormat (ms)|
|-----|--------------|------------------|---------------------|
|1    | 30.20        | 35.50            | 52.78               |
|2    | 28.75        | 34.86            | 54.17               |
|3    | 30.40        | 35.21            | 51.30               |
|4    | 29.63        | 35.42            | 51.90               |
|5    | 30.31        | 34.90            | 52.21               |
|5    | 31.69        | 35.95            | 53.51               |
|6    | 28.90        | 38.00            | 57.59               |
|7    | 28.06        | 33.79            | 51.67               |
|8    | 31.66        | 35.30            | 49.31               |
|9    | 27.49        | 34.80            | 51.42               |
|10   | 30.37        | 35.95            | 48.98               |


Even though the results vary a bit for each paring method it seems clear that, for this particular context, LocalDate is faster than paring LocalTimeDate and both are faster than SimpleDateFormat. Since SimpleDateFormat is the older way to do date parsing while also being a very generalized parser it may make sense that this is less performant than the parse() methods in LocalDate and LocalDateTime. In hind-sight it may also make sense that LocalDate is the faster of the two fastest options since there is no time part for it to parse. Still, the difference is in the 10s of milliseconds for 10,000 dates. Thus, for most use cases this may not be all that big of a difference. But for very high-throughput systems, this may have some measurable impact on performance and sustainability metrics. 


For those interested, the code for this experiment is available in the file [DateParsingBenchmark.java](https://raw.githubusercontent.com/kentis/green_code_experiments/refs/heads/main/Experiments/Parsing%20Dates%20In%20Java/code/DateParsingBenchmark.java), feel free to submit an issue or pull-request if you feel that this experiment should be improved. I re-ran this experiment while varying the order the different ways to parse the dates to ensure consistent results and reduce sources of bias. There did not seem to be any significantly different results from what is presented above.


What are some other common tasks that can be done in several different ways with possible performance and energy use implications?