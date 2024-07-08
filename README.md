# Data Structures and Algorithms

The implementation of some Data Structures and Algorithms in the CLRS.

[Treap](https://jeffe.cs.illinois.edu/teaching/algorithms/notes/03-treaps.pdf)

## Red-Black Tree Rules

1. Root and the leaves (null node) are black.
2. Every red node must have black children.
3. For each node, called X, the number of black nodes on any path from X (not including) to leaves (null node) must be the same (this path is called black-height of the node X, denoted bh(X)).

**Lemma:** A red-black tree with n internal nodes has height at most 2log(n + 1). 
**Note**: bh(root) must be at least h/2.

## Skip List

1. Many layers, each layer has sentinels: -inf and +inf.
2. Each layer is a subset of elements of the layer below.
3. Each layer is sorted in ascending order.
4. Bottom layer contains all the elements in skip list.
5. Each element has a pointer to next element in the same layer and a pointer to same value in the layer below.
