class Solution:
    def shipWithinDays(self, weights: List[int], days: int) -> int:
        lo, hi, res = max(weights), sum(weights), -1
        
        while lo <= hi:
            mid = lo + (hi - lo) // 2
            if self.can_ship_in_days(weights, mid, days):
                res = mid
                hi = mid - 1
            else:
                lo = mid + 1
        
        return res
    
    def can_ship_in_days(self, weights: List[int], capacity: int, days: int) -> bool:
        need_days, sum = 1, 0
        
        for weight in weights:
            sum += weight;
            if sum > capacity:
                need_days += 1
                sum = weight
            
            if need_days > days:
                return False

        return True
