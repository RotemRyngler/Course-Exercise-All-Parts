def pythagorean_triplet_by_sum(sum: int) -> None:
    for a in range(1, sum+1):
        for b in range(a+1, sum+1):
            c = sum-a-b
            if c > b:
                if a**2 + b**2 == c**2:
                    print(f"{a} < {b} < {c}")


pythagorean_triplet_by_sum(144)
