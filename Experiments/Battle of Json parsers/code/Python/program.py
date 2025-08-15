import json
import orjson
import time




def write_json_to_file(obj, filename):
    with open(filename, 'w') as f:
        json.dump(obj, f)

def read_json_with_stdlib(filename):
    with open(filename, 'r') as f:
        return json.load(f)

def read_json_with_orjson(filename):
    with open(filename, 'rb') as f:
        return orjson.loads(f.read())

def estimate_parsing_time(filename, method, repeats=10):
    times = []
    for _ in range(repeats):
        start = time.perf_counter()
        method(filename)
        end = time.perf_counter()
        times.append(end - start)
    avg_time = sum(times) / repeats
    return (avg_time, sum(times))

if __name__ == "__main__":
    filename = "../data/data_1k.json"

    #(stdlib_avg, stdlib_time) = estimate_parsing_time(filename, read_json_with_stdlib)
    (orjson_avg, orjson_time) = estimate_parsing_time(filename, read_json_with_orjson)

    #print(f"Average parsing time with json (stdlib): {stdlib_avg:.6f} seconds. Total {stdlib_time:.6f} seconds.")
    print(f"Average parsing time with orjson: {orjson_avg:.6f} seconds. Total {orjson_time:.6f} seconds")