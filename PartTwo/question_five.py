import math


def reverse_n_pi_digits(n: int) -> str:
    string_pi = str(math.pi).replace(".", "")
    return string_pi[n-1::-1]


print(reverse_n_pi_digits(4))
