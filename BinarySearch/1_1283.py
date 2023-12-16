import math

class Solution:
    def smallestDivisor(self, nums: List[int], threshold: int) -> int:
        lo, hi, res = 1, max(nums), -1
   
        while lo <= hi:
            mid = lo + (hi - lo)//2
            if self.is_less_than_thres(nums, mid, threshold):
                res = mid
                hi = mid -1
            else:
                lo = mid + 1

        return res
    
    def is_less_than_thres(self, nums: List[int], divisor: int, threshold: int) -> bool:
        sum = 0
        for num in nums:
            sum += int(math.ceil(num/divisor))
        return sum <= threshold
        