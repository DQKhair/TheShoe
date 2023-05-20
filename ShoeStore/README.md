# ShoeStore
Web bán giày

*NOTE PROCEDURE
- GetProducts(@qty,@type)
  - @qty là số lượng cần lấy ra (bỏ trống để lấy tất cả)
  - @type 
	- "newest" : lấy các sản phẩm mới nhất trong data(mặc định 15 records)
	- "trending" : lấy các sản phẩm được xem nhiều trong shop(mặc định 15 records)
  - Dữ liệu lấy ra gồm:
	- Mã sản phẩm
	- Tên sản phẩm
	- Giá
	- Hình sản phẩm (lưu dưới dạng nhị phân)
	- Số lượng tương tác
	- Số lượng sản phẩm
	- Ngày thêm sản phẩm
	- Tên loại sản phẩm
	- Số lượng màu sắc của sản phẩm
