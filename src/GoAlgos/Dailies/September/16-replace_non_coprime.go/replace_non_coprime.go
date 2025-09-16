package godailies

func replaceNonCoprimes(nums []int) []int {
	res := nums[:0]
	for _, n := range nums {
		m := n
		for len(res) > 0 {
			top := res[len(res)-1]
			g := gcd(top, m)
			if g == 1 {
				break
			}
			m = (top / g) * m // lcm(top, m)
			res = res[:len(res)-1]
		}
		res = append(res, m)
	}
	return res
}
func gcd(a, b int) int {
	for b != 0 {
		a, b = b, a%b
	}
	return a
}
