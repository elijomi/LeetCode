package godailies

import (
	"slices"
	"testing"
)

func TestReplaceNonCoprimes(t *testing.T) {
	tests := []struct {
		name string
		nums []int
		want []int
	}{
		{"LeetCode sample 1", []int{6, 4, 3, 2, 7, 6, 2}, []int{12, 7, 6}},
		{"LeetCode sample 2", []int{2, 2, 1, 1, 3, 3, 3}, []int{2, 1, 1, 3}},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			got := replaceNonCoprimes(tt.nums)
			if !slices.Equal(got, tt.want) {
				t.Fatalf("replaceNonCoprimes(%v) = %v; want %v", tt.nums, got, tt.want)
			}
		})
	}
}
