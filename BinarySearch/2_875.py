import math

class Solution:
    def minEatingSpeed(self, piles: List[int], h: int) -> int:
        lo, hi, res = 1, max(piles), 0

        while lo <= hi:
            mid = lo + (hi - lo)//2
            if self.can_finish(piles, mid, h):
                res = mid
                hi = mid - 1
            else:
                lo = mid + 1
        
        return res

    def can_finish(self, piles: List[int], k: int, h: int) -> bool:
        count = 0
        for pile in piles:
            count += math.ceil(pile/k)
            if count > h:
                return False
        return True
        