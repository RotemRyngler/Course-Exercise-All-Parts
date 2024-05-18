import math


def num_len(number: int) -> int:
    return int(math.log(number, 10)) + 1


print(num_len(3000000))
