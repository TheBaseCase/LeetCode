class Solution:
    def minimizedMaximum(self, n: int, quantities: List[int]) -> int:
        lo, hi, res = 1, max(quantities), -1

        while lo <= hi:
            mid = lo + (hi - lo)//2
            if self.can_work(quantities, mid, n):
                res = mid
                hi = mid - 1
            else:
                lo = mid + 1
        
        return res
    
    def can_work(self, quantities: List[int], item: int, total_stores: int) -> bool:
        need_store = 0
        
        for quantity in quantities:
            need_store += (quantity - 1)//item + 1
            if need_store > total_stores:
                return False
        
        return True