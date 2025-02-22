# C# Summing Up Numbers: Linq vs foreach vs for

Loops are of particular interest when seeking to optimize for sustainability and/or performance. 
While it is well known that loops are constructs that allows us to do things many times,
what is sometimes forgotten is that the thing in the loop tends to be done many times.

In c# three common ways, there are of course others, to iterate over loops is the `for`, `foreach` loops through `Linq`
which provides ways to do all kinds of things to collections, including looping over them.

In order to study the performance and sustainability of each of these methods to loop over the elements in a list
we will look use each method to get the sum of a large amount of numbers. To do this we have created a .Net program that
sums the numbers 1-1000000000 using a foreach loop, a for loop and Linqs Sum() method. Additionally we use Linq's way to parallelize the Summing by calling `AsParallel()` on the collection before summing, just to see what happens.
 
The results for running the experiments are shown below. As we can see, the traditional for-loop was by far the slowest option followed not all that closely by the foreach lopp. Linq's `Sum()` the fastest non-paralell option with a reasonable margin. Using Linq's `AsParallel()` do additions concurrently, however, was significantly faster than any of the other methods. However, since the parallel may utilize multiple cores, further studies are needed to make any claim on the energy efficiency of this method. Until then it seems likely that the Linq is  generally a good choice when looping over large lists.


|Run #|Foreach (ms)  | For (ms)         | Linq Sum   | Linq Parallel Sum |
|-----|--------------|------------------|------------|-------------------|
|  1  | 3960         | 5536             | 3171       |  871              |
|  2  | 3936         | 5318             | 3186       |  927              |
|  3  | 3894         | 5735             | 3383       |  922              |
|  4  | 4042         | 5491             | 3134       |  779              |
|  5  | 3913         | 5480             | 3240       |  837              |
|  6  | 4021         | 5395             | 3093       |  735              |
|  7  | 4109         | 5424             | 3200       |  829              |
|  8  | 3959         | 5395             | 3130       |  740              |
|  9  | 3896         | 5432             | 3048       |  739              |
| 10  | 4043         | 5542             | 3059       |  746              |
|-----|--------------|------------------|------------|-------------------|
| Avg | 3977         | 5475             | 3164       |  812              |


![summing results as graph](summing_results_graph.png)

Are there any interesting looping methods I missed in this study?

What are some other common tasks that can be done in several different ways with possible performance and energy use implications?

For those interested, the code for this experiment is available in the file [Program.cs](https://raw.githubusercontent.com/kentis/green_code_experiments/refs/heads/summing_numbers/Experiments/Summing%20numbers%20linq%20vs%20foreach/code/Program.cs), feel free to submit an issue or pull-request if you feel that this experiment should be improved. I re-ran this experiment while varying the order the different ways to parse the dates to ensure consistent results and reduce sources of bias. There did not seem to be any significantly different results from what is presented above.

