class Solution:
    def minDays(self, bloomDay: List[int], m: int, k: int) -> int:
        lo, hi, res = min(bloomDay), max(bloomDay), -1

        while lo <= hi:
            mid = lo + (hi - lo) // 2
            if self.can_get_bouquets(bloomDay, mid, m, k):
                res = mid
                hi = mid - 1
            else:
                lo = mid + 1
        
        return res
    
    def can_get_bouquets(self, flowers: List[int], day: int, num_bouquets: int, adjacent_flowers: int) -> bool:
        flowers_picked = 0
        
        for i in range(len(flowers)):
            if flowers[i] <= day:
                flowers_picked += 1
            else:
                flowers_picked = 0
            
            if flowers_picked == adjacent_flowers:
                flowers_picked = 0
                num_bouquets -= 1
            
            if num_bouquets == 0:
                return True
        
        return False