from fastapi import APIRouter
import numpy as nump

router = APIRouter()


@router.get('')
def matrix() -> dict:
    matrix1 = nump.random.rand(10, 10)
    matrix2 = nump.random.rand(10, 10)
    mulMatrix = nump.matmul(matrix1, matrix2)
    return {'msg': 
	{ 
	'matrix_a': str(matrix1).replace('\n', ','), 
	'matrix_b': str(matrix2).replace('\n', ','), 
	'product': str(mulMatrix).replace('\n', ',') 
	}}