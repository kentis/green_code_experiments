import json
import random
import string
import time

def random_string(length=10):
    return ''.join(random.choices(string.ascii_letters + string.digits, k=length))

def random_number():
    return random.randint(0, 10**6)

def random_boolean():
    return random.choice(["true", "false"])

def random_list(size=10):
    return [random.choice([random_string(), random_number(), random_boolean()]) for _ in range(size)]

def random_object(depth=3, width=5):
    if depth == 0:
        return {random_string(): random.choice([random_string(), random_number(), random_boolean()]) for _ in range(width)}
    return {random_string(): random_object(depth-1, width) for _ in range(width)}

def generate_large_json(size=1000, depth=3, width=5):
    return {
        "metadata": {
            "generated_at": time.strftime("%Y-%m-%d %H:%M:%S"),
            "entries": size
        },
        "data": [random_object(depth, width) for _ in range(size)]
    }


if __name__ == "__main__":
    print(generate_large_json(size=1000, depth=2, width=5))