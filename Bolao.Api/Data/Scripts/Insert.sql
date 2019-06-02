-- USER
INSERT INTO user VALUES ('22107bfd-3806-4304-915a-1a62834a6cea', 'Wellington', 'Fernandes', 'wellington.m.fernandes@gmail.com', '123456', NOW(), 1);

-- TYPEBET
INSERT INTO typebet VALUES (1, 'Sena15Numbers', 'Descição');

-- LOTTERY / LOTERRY NUMBER RESULT
INSERT INTO lottery VALUES ('aefa86bb-f329-4f69-a024-b106a7b372e8', 17.50, NOW(), NOW(), DATE(NOW() + INTERVAL 3 DAY), NOW(), 1, 1);
INSERT INTO lotterynumberresult VALUES (1, '01', 'aefa86bb-f329-4f69-a024-b106a7b372e8');
INSERT INTO lotterynumberresult VALUES (2, '02', 'aefa86bb-f329-4f69-a024-b106a7b372e8');
INSERT INTO lotterynumberresult VALUES (3, '03', 'aefa86bb-f329-4f69-a024-b106a7b372e8');
INSERT INTO lotterynumberresult VALUES (4, '04', 'aefa86bb-f329-4f69-a024-b106a7b372e8');
INSERT INTO lotterynumberresult VALUES (5, '05', 'aefa86bb-f329-4f69-a024-b106a7b372e8');
INSERT INTO lotterynumberresult VALUES (6, '06', 'aefa86bb-f329-4f69-a024-b106a7b372e8');

INSERT INTO lottery VALUES ('5c42ca49-f3c8-4e5b-a72c-c46a871cd748', 20.10, NOW(), NOW(), DATE(NOW() + INTERVAL 7 DAY), NOW(), 1, 1);
INSERT INTO lotterynumberresult VALUES (7, '07', '5c42ca49-f3c8-4e5b-a72c-c46a871cd748');
INSERT INTO lotterynumberresult VALUES (8, '08', '5c42ca49-f3c8-4e5b-a72c-c46a871cd748');
INSERT INTO lotterynumberresult VALUES (9, '09', '5c42ca49-f3c8-4e5b-a72c-c46a871cd748');
INSERT INTO lotterynumberresult VALUES (10, '10', '5c42ca49-f3c8-4e5b-a72c-c46a871cd748');
INSERT INTO lotterynumberresult VALUES (11, '11', '5c42ca49-f3c8-4e5b-a72c-c46a871cd748');
INSERT INTO lotterynumberresult VALUES (12, '12', '5c42ca49-f3c8-4e5b-a72c-c46a871cd748');